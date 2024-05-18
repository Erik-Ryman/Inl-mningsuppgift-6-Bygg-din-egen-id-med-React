import { CompanyUser, PrivateUser } from "@/models/Authentication";
import { create } from "zustand";

type UserStore = {
	user: string | null;
	jwtToken: string | null;
	refreshToken: string | null;
	expirationDate: Date | null;
	isLoggedIn: boolean;
	setUser: (user: string | null) => void;
	setJwtToken: (jwtToken: string | null) => void;
	setRefreshToken: (refreshToken: string | null) => void;
	setExpirationDate: (expirationDate: Date | null) => void;
	setIsLoggedIn: (isLoggedIn: boolean) => void;
};

export const useUserStore = create<UserStore>((set) => ({
	user: null,
	jwtToken: null,
	refreshToken: null,
	expirationDate: null,
	isLoggedIn: false,
	setUser: (user) => set({ user }),
	setJwtToken: (jwtToken) => set({ jwtToken }),
	setRefreshToken: (refreshToken) => set({ refreshToken }),
	setExpirationDate: (expirationDate) => set({ expirationDate }),
	setIsLoggedIn: (isLoggedIn) => set({ isLoggedIn }),
}));
