import { FC, MouseEvent } from 'react';
import AssemblyUnitDTO from '../models/AssemblyUnitDTO';


interface AssemblyUnitBlockProps {
    assemblyUnit: AssemblyUnitDTO,
    selected: boolean,
    valid: number,
    index: number,
    onClick: (id: number) => void
}

const AssemblyUnitBlock: FC<AssemblyUnitBlockProps> = ({ assemblyUnit, selected, valid, index, onClick }) => {

    const validClass = valid === 1 ? ' valid' : '';
    const selectedClass = selected ? ' selected' : '';
    const invalidClass = valid === -1 ? ' invalid' : '';
    const classes: string = validClass + selectedClass + invalidClass + ' ct-item';


    const handleClick = (e: MouseEvent<HTMLDivElement>) => {
        onClick(assemblyUnit.kse);
    }

    return (
        <div className={classes} onClick={handleClick}>
            <p><b>Сборочная единица: {index}</b></p>
            <p>Наименование СЕ: {assemblyUnit.nse}</p>
            <p>Тип сборочной единицы: {assemblyUnit.tse}</p>
            <p>Статус расчёта: {assemblyUnit.s === undefined ? "необходим расчёт" : assemblyUnit.s}</p>
        </div>
    );
}


export default AssemblyUnitBlock;