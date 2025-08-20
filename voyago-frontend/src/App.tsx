import { Navigate, Route, Routes } from "react-router-dom"
import Login from "./pages/Login"
import Register from "./pages/Register" 
import Home from "./pages/Home"
import ResetPasswordRequest from "./pages/ResetPasswordRequest"
import UpdatePassword from "./pages/UpdatePassword"
// import { useAppSelector } from "./state/hooks"

function App() {

  // const isAuth = Boolean(useAppSelector((state) => state.auth.token));

  return (
    <>
        <Routes>
          <Route path="/" element={<Navigate to="/auth/login" replace />} />
          <Route path="/auth/login" element={<Login />} />
          <Route path="/auth/register" element={<Register />} />
          <Route path="/auth/reset-password" element={<UpdatePassword />} />
          <Route path="/auth/forgot-password" element={<ResetPasswordRequest />} />
          <Route path="/home" element={<Home />} />
        </Routes>
    </>
  )
}

export default App
