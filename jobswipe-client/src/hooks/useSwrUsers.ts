import { PrivateUser } from "@/models/Authentication";
import { AUTH } from "@/services/ApiService";
import useSwr from "swr";

const API_URL = "https://localhost:7134/api";

const fetcher = async (url: string): Promise<PrivateUser[]> => {
	const jwtToken = await AUTH.getJwtToken();
	const response = await fetch(url, {
		headers: {
			"Content-Type": "application/json",
			Accept: "application/json",
			Authorization: `Bearer ${jwtToken}`,
		},
	});
	if (!response.ok) {
		throw new Error(response.status.toString());
	}
	return await response.json();
};

const useSwrUsers = () => {
	const { data, error } = useSwr(`${API_URL}/Users/private`, fetcher);

	return {
		users: data,
		isLoading: !error && !data,
		isError: error,
	};
};

export default useSwrUsers;
