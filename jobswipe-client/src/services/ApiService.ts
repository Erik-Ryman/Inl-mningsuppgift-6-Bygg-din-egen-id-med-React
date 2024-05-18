import { RegisterCompanyUserDTO, RegisterPrivateUserDTO } from "@/models/Authentication";

export const API_URL = "https://localhost:7134";

export const AUTH_ENDPOINTS = {
	LOGIN: `${API_URL}/api/Auth/Login/`,
	REGISTER_PRIVATE_USER: `${API_URL}/api/Auth/RegisterPrivateUser/`,
	REGISTER_COMPANY_USER: `${API_URL}/api/Auth/RegisterCompanyUser/`,
	REFRESH: `${API_URL}/api/Auth/Refresh/`,
};

export const JOBS_ENDPOINTS = {
	GET_ALL: `${API_URL}/api/Jobs/`,
	GET_BY_ID: `${API_URL}/api/Jobs/`,
	GET_MATCHING_JOBS: `${API_URL}/api/Jobs/matchingJobs/`,
	CREATE: `${API_URL}/api/Jobs/`,
	DELETE: `${API_URL}/api/Jobs/`,
	UPDATE: `${API_URL}/api/Jobs/`,
};

export const USERS_ENDPOINTS = {
	GET_ALL: `${API_URL}/api/Users/`,
	GET_BY_ID: `${API_URL}/api/Users/`,
	DELETE: `${API_URL}/api/Users/`,
	UPDATE: `${API_URL}/api/Users/`,
};

export const MATCHES_ENDPOINTS = {
	GET_ALL: `${API_URL}/api/Matches/`,
	GET_BY_ID: `${API_URL}/api/Matches/`,
	CREATE: `${API_URL}/api/Matches/`,
	DELETE: `${API_URL}/api/Matches/`,
	UPDATE: `${API_URL}/api/Matches/`,
};

export const SKILLS_ENDPOINTS = {
	GET_ALL: `${API_URL}/api/Skills/`,
	GET_BY_ID: `${API_URL}/api/Skills/`,
	CREATE: `${API_URL}/api/Skills/`,
	DELETE: `${API_URL}/api/Skills/`,
	UPDATE: `${API_URL}/api/Skills/`,
};

export const SWIPES_ENDPOINTS = {
	GET_ALL: `${API_URL}/api/Swipes/`,
	GET_BY_ID: `${API_URL}/api/Swipes/`,
	CREATE: `${API_URL}/api/Swipes/`,
	DELETE: `${API_URL}/api/Swipes/`,
	UPDATE: `${API_URL}/api/Swipes/`,
};

export const API = {
	async createOrUpdateMatch(userId: string, jobId: string) {
		const response = await fetch(MATCHES_ENDPOINTS.CREATE, {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify({ userId, jobId }),
		});
		return response.ok;
	},

	async getUserByEmail(email: string) {
		const response = await fetch(`${USERS_ENDPOINTS.GET_ALL}${email}`, {
			method: "GET",
			headers: { "Content-Type": "application/json" },
		});
		return await response.json();
	},
};

export const AUTH = {
	async registerPrivateUser(registerUserObject: RegisterPrivateUserDTO) {
		await fetch(AUTH_ENDPOINTS.REGISTER_PRIVATE_USER, {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify(registerUserObject),
		});
	},

	async registerCompanyUser(registerUserObject: RegisterCompanyUserDTO) {
		await fetch(AUTH_ENDPOINTS.REGISTER_COMPANY_USER, {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify(registerUserObject),
		});
	},

	async authenticateUser(email: string, password: string) {
		const response = await fetch(AUTH_ENDPOINTS.LOGIN, {
			method: "POST",
			headers: { "Content-Type": "application/json" },
			body: JSON.stringify({ email, password }),
		});
		if (!response.ok) {
			throw new Error("Authentication failed. Please check your email and password.");
		}
		const responseJson = await response.json();
		localStorage.setItem("email", email);
		return responseJson;
	},

	async refreshJwtToken(refreshToken: string, jwtToken: string | null) {
		const response = await fetch(AUTH_ENDPOINTS.REFRESH, {
			method: "POST",
			headers: {
				"Content-Type": "application/json",
			},
			body: JSON.stringify({ refreshToken, jwtToken }),
		});

		return response.json();
	},

	async getJwtToken(): Promise<string> {
		const jwtToken = localStorage.getItem("jwtToken");
		const expiration = localStorage.getItem("expiration");

		if (jwtToken && Number(expiration) > Date.now()) {
			return jwtToken;
		}

		const refreshToken = localStorage.getItem("refreshToken");

		if (!refreshToken) {
			return "";
		}

		const response = await AUTH.refreshJwtToken(refreshToken, jwtToken);

		AUTH.handleAuthResponse(response);

		return response.jwtToken;
	},

	handleAuthResponse(response: any) {
		const jwtToken = response.jwtToken;
		const refreshToken = response.refreshToken;
		const expiration = new Date(response.expiration);

		localStorage.setItem("jwtToken", jwtToken);
		localStorage.setItem("refreshToken", refreshToken);
		localStorage.setItem("expiration", String(expiration));
	},

	logout() {
		localStorage.removeItem("jwtToken");
		localStorage.removeItem("refreshToken");
		localStorage.removeItem("expiration");
		localStorage.removeItem("email");
		window.location.assign("/login");
	},
};
