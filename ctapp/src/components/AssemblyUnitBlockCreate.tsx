import { FC, FormEvent, ChangeEvent, useState } from 'react';
import AssemblyUnitDTO from '../models/AssemblyUnitDTO';
import { createAssemblyUnit } from '../requests';


interface AssemblyUnitBlockCreateProps {
    selectedUnitId: number,
    addAssemblyUnit: (AssemblyUnits: AssemblyUnitDTO) => void
}

const AssemblyUnitBlockCreate: FC<AssemblyUnitBlockCreateProps> = ({ selectedUnitId, addAssemblyUnit }) => {

    const initAssemblyUnit: AssemblyUnitDTO = {
        kse: 0,
        nse: '',
        tse: 'Цепная',
        sm: 'Периодическая регулярная',
        t: 0,
        unitKU: selectedUnitId
    };

    const [assemblyUnit, setAssemblyUnit] = useState<AssemblyUnitDTO>(initAssemblyUnit);

    const handleChange = (e: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.currentTarget;
        setAssemblyUnit(
            {
                ...assemblyUnit,
                [name]: value
            })
    }


    const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (assemblyUnit.nse && assemblyUnit.tse && assemblyUnit.sm && assemblyUnit.t) {
            createAssemblyUnit(assemblyUnit)
                .then((queryObject) => {
                    addAssemblyUnit({
                        ...assemblyUnit,
                        kse: queryObject.id
                    });
                })
                .catch(error => console.error(error));
        }
    }

    return (
        <form className='ct-creation' onSubmit={handleSubmit}>
            <div>
                <p>Название сборочной единицы: </p>
                <input name='nse' type="text" onChange={handleChange} />
            </div>

            <div>
                <p>Тип сборочной единицы: </p>
                <select name="tse" id="" onChange={handleChange}>
                    <option value="Цепная">Цепная</option>
                </select>
            </div>
            <div>
                <p>Смазочный материал: </p>
                <select name="sm" id="" onChange={handleChange}>
                    <option value="Периодическая регулярная">Периодическая регулярная</option>
                    <option value="Капельная">Капельная</option>
                    <option value="Масляная ванна">Масляная ванна</option>
                </select>
            </div>
            <div>
                <p>Время работы: </p>
                <input name='t' type="number" min={1} onChange={handleChange} />
            </div>
            <p></p>
            <button type='submit'>Создать</button>
        </form>
    );
}


export default AssemblyUnitBlockCreate;