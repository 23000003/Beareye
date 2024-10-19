import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App'
import './index.css'
import AppRoute from './Route'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <AppRoute />
  </StrictMode>,
)