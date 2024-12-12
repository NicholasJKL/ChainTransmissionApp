import { FC, FormEvent, ChangeEvent, useState } from 'react';
import UnitDTO from '../models/UnitDTO';
import { createUnit } from '../requests';


interface UnitBlockCreateProps {
    addUnit: (units: UnitDTO) => void
}

const UnitBlockCreate: FC<UnitBlockCreateProps> = ({addUnit }) => {

    const initUnit: UnitDTO = {
        ku: 0,
        nu: '',
        tu: 'Внутреннего сгорания с гидравлическим приводом',
        tn: 'Спокойная',
        vu: '',
        n: 0
    };

    const [unit, setUnit] = useState<UnitDTO>(initUnit);

    const handleChange = (e: ChangeEvent<HTMLInputElement> | ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.currentTarget;

        setUnit(
            {
                ...unit,
                [name]: value
            })
    }


    const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        if (unit.nu && unit.tu && unit.tn && unit.vu && unit.n > 0) {
            createUnit(unit)
                .then(() => {
                    addUnit(unit);
                })
                .catch(error => console.error(error));
        }
    }

    return (
        <form className='ct-creation' onSubmit={handleSubmit}>
            <div>
                <p>Название узла: </p>
                <input name='nu' type="text" onChange={handleChange} />
            </div>

            <div>
                <p>Тип узла: </p>
                <select name="tu" id="" onChange={handleChange}>
                    <option value="Внутреннего сгорания с гидравлическим приводом">Внутреннего сгорания с гидравлическим приводом</option>
                    <option value="Электромотор или турбина">Электромотор или турбина</option>
                    <option value="Внутреннего сгорания с механическим приводом">Внутреннего сгорания с механическим приводом</option>
                </select>
            </div>
            <div>
                <p>Вид узла: </p>
                <input name='vu' type="text" onChange={handleChange} />
            </div>
            <div>
                <p>Тип нагрузки: </p>
                <select name="tn" id="" onChange={handleChange}>
                    <option value="Спокойная">Спокойная</option>
                    <option value="Умеренная">Умеренная</option>
                    <option value="Тяжелые толчки и удары">Тяжелые толчки и удары</option>
                </select>
            </div>
            <div>
                <p>Мощность узла: </p>
                <input name='n' type="number" min={1} onChange={handleChange} />
            </div>
            <button type='submit'>Создать</button>
        </form>
    );
}


export default UnitBlockCreate;