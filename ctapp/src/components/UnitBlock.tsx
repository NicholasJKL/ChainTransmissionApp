import { FC, MouseEvent } from 'react';
import UnitDTO from '../models/UnitDTO';


interface UnitBlockProps {
    unit: UnitDTO,
    selected: boolean,
    index: number,
    onClick: (id: number) => void,
    onSelection: (index: number) => void
}

const UnitBlock: FC<UnitBlockProps> = ({ unit, selected, index, onClick, onSelection }) => {

    const handleClick = (e: MouseEvent<HTMLDivElement>) => {
        onClick(unit.ku);
        onSelection(index);
    }

    return (
        <div className={selected ? 'ct-item selected' : 'ct-item'} onClick={handleClick}>
            <p><b>Узел: {index}</b></p>
            <p>Наименование узла: {unit.nu}</p>
            <p>Тип узла: {unit.tu}</p>
            <p>Вид узла: {unit.vu}</p>
        </div>
    );
}


export default UnitBlock;