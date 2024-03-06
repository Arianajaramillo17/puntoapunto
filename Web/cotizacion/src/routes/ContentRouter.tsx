import { Route, Routes, useNavigate } from 'react-router-dom'
import Cotizacion from '../pages/cotizacion/Cotizacion'
import { Verified } from './Verified'

const ContentRouter = () => {

  return (
    <>
      <Routes>
        <Route path='/cotizacion' element={<Verified />}>
          <Route path="listado" element={<Cotizacion />} />
        </Route>

      </Routes>
    </>
  )
}

export default ContentRouter