import { PrivateUser, CompanyUser } from "@/models/Authentication";
import { AUTH } from "@/services/ApiService";
import useSwr from "swr";

const API_URL = "https://localhost:7134/api";

const fetcher = async (url: string): Promise<PrivateUser | CompanyUser> => {
	const jwtToken = await AUTH.getJwtToken();
	const response = await fetch(url, {
		headers: {
			"Content-Type": "application/json",
			Accept: "application/json",
			Authorization: `Bearer ${jwtToken}`,
		},
	});
	return await response.json();
};

const useSwrUser = (email: string) => {
	const { data, error } = useSwr(`${API_URL}/Users/${email}/`, fetcher);

	return {
		user: data,
		isLoading: !error && !data,
		isError: error,
	};
};

export default useSwrUser;
