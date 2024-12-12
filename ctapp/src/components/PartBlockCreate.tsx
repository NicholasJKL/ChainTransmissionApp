import { FC, FormEvent, ChangeEvent, useState } from 'react';
import PartDTO from '../models/PartDTO';
import { createPart } from '../requests';


interface PartCreateProps {
    addPart: (parts: PartDTO) => void
}

const PartCreate: FC<PartCreateProps> = ({ addPart }) => {

    const [partType, setPartType] = useState<string>('Колесо');

    const initpart: PartDTO = {
        kd: 0,
        nd: 'Колесо',
        td: '',
        assemblyUnitKSE: 0
    };

    const [part, setPart] = useState<PartDTO>(initpart);

    const handleChange = (e: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.currentTarget;

        setPart(
            {
                ...part,
                [name]: value
            })
    }

    const handlePartTypeChange = (e: ChangeEvent<HTMLSelectElement>) => {
        setPartType(e.currentTarget.value);
    }


    const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        let valid = false;
        console.log(part);
        if (part.nd === 'Колесо') {
            if (part.td && part.naD && typeof(part.z) === 'number') {
                valid = true;
            }
            else {
                if (part.td) {
                    switch (part.nd[0]) {
                        case ('2'):
                            {
                                part.vd = 'Двухрядная';
                                break;
                            }
                        case ('3'):
                            {
                                part.vd = 'Трёхрядная';
                                break;
                            }
                        case ('4'):
                            {
                                part.vd = 'Четырёхрядная';
                                break;
                            }
                        default: {
                            part.vd = 'Однорядная'
                        }
                    }
                    valid = true;
                }
            }
        }
        if (valid) {
            createPart(part)
                .then(() => {
                    addPart(part);
                })
                .catch(error => console.error(error));
        }
    }

    return (
        <form className='ct-creation' onSubmit={handleSubmit}>
            <div>
                <p>Деталь: </p>
                <select name="tu" id="" onChange={handlePartTypeChange}>
                    <option value="Колесо">Колесо</option>
                    <option value="Цепь">Цепь</option>
                </select>
            </div>
            {
                partType === 'Колесо' ?
                    <>
                        <div>
                            <p>Тип колеса: </p>
                            <select name="td" id="" onChange={handleChange}>
                                <option value=""></option>
                                <option value="Зубчатое">Зубчатое</option>
                            </select>
                        </div>
                        <div>
                            <p>Назначение: </p>
                            <select name="naD" id="" onChange={handleChange}>
                                <option value=""></option>
                                <option value="Ведущее">Ведущее</option>
                                <option value="Ведомое">Ведомое</option>
                            </select>
                        </div>
                        <div>
                            <p>Число зубьев: </p>
                            <select name="z" id="" onChange={handleChange}>
                                <option value=""></option>
                                <option value={20}>20</option>
                                <option value={25}>25</option>
                                <option value={30}>30</option>
                            </select>
                        </div>
                    </>
                    :
                    <>
                        <div>
                            <p>Наименование цепи: </p>
                            <select name="nd" id="" onChange={handleChange}>
                                <option value=""></option>
                                <option value="ПР-12,7-1820-2">ПР-12,7-1820-2</option>
                                <option value="2ПР-12,7-3180">2ПР-12,7-3180</option>
                                <option value="ПР-15,875-2270-2">ПР-15,875-2270-2</option>
                                <option value="2ПР-15,875-4540">2ПР-15,875-4540</option>
                                <option value="ПР-19,05-3180">ПР-19,05-3180</option>
                                <option value="2ПР-19,05-7200">2ПР-19,05-7200</option>
                                <option value="ПР-25,4-5670">ПР-25,4-5670</option>
                                <option value="2ПР-25,4-11340">2ПР-25,4-11340</option>
                                <option value="ПР-31,75-8850">ПР-31,75-8850</option>
                                <option value="2ПР-31,75-17700">2ПР-31,75-17700</option>
                                <option value="ПР-38,1-12700">ПР-38,1-12700</option>
                                <option value="2ПР-38,1-25400">2ПР-38,1-25400</option>
                                <option value="ПР-44,45-17240">ПР-44,45-17240</option>
                                <option value="2ПР-44,45-34480">2ПР-44,45-34480</option>
                                <option value="ПР-50,8-22680">ПР-50,8-22680</option>
                                <option value="2ПР-50,8-45360">2ПР-50,8-45360</option>
                            </select>
                            <div>
                                <p>Тип цепи: </p>
                                <select name="td" id="" onChange={handleChange}>
                                    <option value=""></option>
                                    <option value="Ведущее">Приводная роликовая</option>
                                </select>
                            </div>
                        </div>
                    </>
            }

            <button type='submit'>Создать</button>
        </form>
    );
}


export default PartCreate;