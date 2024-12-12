import { FC, useState, useEffect, FormEvent } from 'react';
import './styles.css'

import UnitBlock from './components/UnitBlock';
import UnitBlockCreate from './components/UnitBlockCreate';
import AssemblyUnitBlock from './components/AssemblyUnitBlock'
import UnitDTO from './models/UnitDTO';
import AssemblyUnitDTO from './models/AssemblyUnitDTO';
import PartDTO from './models/PartDTO'
import PartBlock from './components/PartBlock';
import AssemblyUnitBlockCreate from './components/AssemblyUnitBlockCreate';
import { getAssemblyUnitsByUnit, getPartsByAssemblyUnit, getStatuses, getUnits } from './requests';
import PartBlockCreate from './components/PartBlockCreate';


const App: FC = () => {

	const [units, setUnits] = useState<UnitDTO[]>([]);
	const [assemblyUnits, setAssemblyUnits] = useState<AssemblyUnitDTO[]>([]);
	const [parts, setParts] = useState<PartDTO[]>([]);

	const [selectedUnitIndex, setSelectedUnitIndex] = useState<number | null>(null);
	const [selectedUnitId, setSelectedUnitId] = useState<number | null>(null);
	const [selectedAssemblyUnitId, setSelectedAssemblyUnitId] = useState<number | null>(null);

	useEffect(() => {
		getUnits()
			.then(queryObject => {
				if (queryObject) {
					setUnits(queryObject)
				}
			}
			);
	}, []
	);

	useEffect(() => {
		setParts([]);
		setSelectedAssemblyUnitId(null);
		if (selectedUnitId)
			getAssemblyUnitsByUnit(selectedUnitId)
				.then(queryObject => {
					if (queryObject) {
						setAssemblyUnits(queryObject);
						queryObject.forEach(assemblyUnit => {
							assemblyUnit.s = undefined;
						})

					}
				})
	}, [selectedUnitId]);

	useEffect(() => {
		if (selectedAssemblyUnitId)
			getPartsByAssemblyUnit(selectedAssemblyUnitId)
				.then(queryObject => {
					if (queryObject)
						setParts(queryObject);
				})
	}, [selectedAssemblyUnitId]);

	const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
		e.preventDefault();
		if (selectedUnitId) {
			getStatuses(selectedUnitId)
				.then(queryObject => {
					console.log(queryObject)
					if (queryObject)
						setAssemblyUnits(queryObject)
				})
				.catch(error => console.error(error));
		}
	}

	const addUnit = (newUnit: UnitDTO) => {
		setUnits([...units, newUnit]);
	}

	const addAssemblyUnit = (newAssemblyUnit: AssemblyUnitDTO) => {
		setAssemblyUnits([...assemblyUnits, newAssemblyUnit]);
	}

	const addPart = (newPart: PartDTO) => {
		setParts([...parts, newPart]);
	}

	return (
		<main>
			<div className='ct-grid'>
				<div className='ct-grid-block'>
					<h1>Узлы</h1>
					<div className='ct-block'>
						<UnitBlockCreate addUnit={addUnit}></UnitBlockCreate>
						{
							units.map((unit, index) => {
								let selected = false;
								if (unit.ku === selectedUnitId) {
									selected = true;
								}
								return <UnitBlock
									key={unit.ku}
									unit={unit}
									onClick={setSelectedUnitId}
									onSelection={setSelectedUnitIndex}
									selected={selected}
									index={index + 1}></UnitBlock>
							})
						}
					</div>
				</div>
				<div className='ct-grid-block'>
					<h1>Сборочные единицы</h1>
					<div className='ct-block'>
						{selectedUnitId === null ? <></>
							:
							<AssemblyUnitBlockCreate
								addAssemblyUnit={addAssemblyUnit}
								selectedUnitId={selectedUnitId}></AssemblyUnitBlockCreate>
						}
						{

							assemblyUnits.map((assemblyUnit, index) => {
								let selected = false, valid = 0;
								if (assemblyUnit.kse === selectedAssemblyUnitId) {
									selected = true;
								}
								if (assemblyUnit.s) {
									valid = assemblyUnit.s === 'Допустимо' ? 1 : -1;
								}

								return <AssemblyUnitBlock
									key={index}
									assemblyUnit={assemblyUnit}
									onClick={setSelectedAssemblyUnitId}
									selected={selected}
									valid={valid}
									index={index + 1}></AssemblyUnitBlock>
							})
						}
					</div>
				</div>
				<div className='ct-grid-block'>
					<h1>Детали</h1>
					<div className='ct-block'>
					{selectedAssemblyUnitId === null ? <></>
							:
						<PartBlockCreate addPart={addPart}></PartBlockCreate>
					}
						{
							parts.map(part => {
								return <PartBlock key={part.kd} part={part}></PartBlock>
							})
						}
					</div>
				</div>
			</div>
			<form className='ct-monitor' onSubmit={handleSubmit}>
				<button type='submit'>Расчёт</button>
				<p>Выбранный узел: {selectedUnitIndex ?? 'Не выбран'}</p>
			</form>
		</main>
	);
}

export default App;
