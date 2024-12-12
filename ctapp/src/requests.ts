import AssemblyUnitDTO from "./models/AssemblyUnitDTO";
import UnitDTO from "./models/UnitDTO";
import PartDTO from "./models/PartDTO";


const getUnits = async (): Promise<UnitDTO[] | undefined> => {
    try {
        const response = await fetch('http://localhost:5182/GetUnits');
        console.log(response);
        if (response.ok) {
            const json = await response.json();
            return json;
        }
        throw new Error('Ошибка при запросе: ' + response.status);
    }
    catch (error) {
        console.error(error);
    }
}

const getAssemblyUnitsByUnit = async (unitKey: number): Promise<AssemblyUnitDTO[] | undefined> => {
    try {
        const response = await fetch(`http://localhost:5182/GetAssemblyUnitsByUnit?unitKey=${unitKey}`);
        if (response.ok) {
            const json = await response.json();
            return json;
        }
        throw new Error('Ошибка при запросе: ' + response.status);
    }
    catch (error) {
        console.error(error);
    }
}

const getPartsByAssemblyUnit = async (assemblyUnitKey: number): Promise<PartDTO[] | undefined> => {
    try {
        const response = await fetch(`http://localhost:5182/GetPartsByAssemblyUnit?assemblyUnitKey=${assemblyUnitKey}`);
        if (response.ok) {
            const json = await response.json();
            return json;
        }
        throw new Error('Ошибка при запросе: ' + response.status);
    }
    catch (error) {
        console.error(error);
    }
}

const getStatuses = async (unitKey: number): Promise<AssemblyUnitDTO[] | undefined> => {
    try {
        const response = await fetch(`http://localhost:5182/GetStatuses?unitKey=${unitKey}`);
        const json = await response.json();
        if (response.ok) {
            return json;
        }
        throw new Error('Ошибка при запросе: ' + json);
    }
    catch (error) {
        throw(error);
    }
}

const createUnit = async (unit: UnitDTO): Promise<any> => {
    try {
        const response = await fetch('http://localhost:5182/CreateUnit', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(unit)
        })
        return await response.json();
    }
    catch (error) {
        console.error(error);
    }
}

const createAssemblyUnit = async (assemblyUnit: AssemblyUnitDTO): Promise<any> => {
    try {
        const response = await fetch('http://localhost:5182/CreateAssemblyUnit', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(assemblyUnit)
        })
        return await response.json();
    }
    catch (error) {
        console.error(error);
    }
}

const createPart = async (part: PartDTO): Promise<any> => {
    try {
        const response = await fetch('http://localhost:5182/CreatePart', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(part)
        })
        return await response.json();
    }
    catch (error) {
        console.error(error);
    }
}


export {
    getUnits, getAssemblyUnitsByUnit, getPartsByAssemblyUnit,
    getStatuses, createUnit, createAssemblyUnit, createPart
};