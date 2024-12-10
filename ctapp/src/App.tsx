import { FC } from 'react';
import './styles.css'

import UnitBlock from './components/UnitBlock';


const App: FC = () => {
  return (
    <main>
      <div className='ct-grid'>
        <div className='ct-block'>
          <UnitBlock></UnitBlock>
        </div>
        <div className='ct-block'></div>
        <div className='ct-block'></div>
      </div>
      <div className='ct-monitor'></div>
    </main>
  );
}

export default App;
