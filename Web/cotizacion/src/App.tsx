
import { BrowserRouter } from 'react-router-dom'
import './App.css'
import ContentRouter from './routes/ContentRouter'

function App() {

  return (
    <> <BrowserRouter>
      <ContentRouter />
    </BrowserRouter>
    </>
  )
}

export default App
