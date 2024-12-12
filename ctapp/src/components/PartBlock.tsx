import { FC } from 'react';
import PartDTO from '../models/PartDTO';


interface PartBlockProps {
    part: PartDTO
}

const PartBlock: FC<PartBlockProps> = ({ part }) => {
    return (
        <div className='ct-item'>
            <p><b>Код детали: {part.kd}</b></p>
            <p>Наименование детали: {part.nd}</p>
            <p>Тип детали: {part.td}</p>
            <p>Вид детали: {part.vd}</p>
            <p>Назначение детали: {part.naD}</p>
        </div>
    );
}


export default PartBlock;