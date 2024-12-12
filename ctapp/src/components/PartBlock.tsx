import { FC } from 'react';
import PartDTO from '../models/PartDTO';


interface PartBlockProps {
    part: PartDTO,
    index: number
}

const PartBlock: FC<PartBlockProps> = ({ part, index }) => {
    return (
        <div className='ct-item'>
            <p><b>Деталь: {index}</b></p>
            <p>Наименование детали: {part.nd}</p>
            <p>Тип детали: {part.td}</p>
            <p>Вид детали: {part.vd}</p>
            <p>Назначение детали: {part.naD}</p>
        </div>
    );
}


export default PartBlock;