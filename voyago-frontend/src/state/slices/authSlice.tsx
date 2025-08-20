import {createSlice} from "@reduxjs/toolkit";

const initialState: {
    accessToken: string | null;
    refreshToken: string | null;

} = {
    accessToken: localStorage.getItem("token") || null,
    refreshToken: localStorage.getItem("refreshToken") || null,
};

export const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        setLogin: (state, action) => {
            state.accessToken = action.payload.accessToken;
            state.refreshToken = action.payload.refreshToken;
        },
        setLogout: (state) => {
            state.accessToken = null;
            state.refreshToken = null;
        },
    }
});

export const { setLogin, setLogout } =
  authSlice.actions;
export default authSlice.reducer;