import { Job } from "@/models/Job";
import { AUTH } from "@/services/ApiService";
import useSwr from "swr";

const API_URL = "https://localhost:7134/api";

const fetcher = async (url: string): Promise<Job[]> => {
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

const useSwrJobs = () => {
	const { data, error } = useSwr(`${API_URL}/Jobs/`, fetcher);

	return {
		jobs: data,
		isLoading: !error && !data,
		isError: error,
	};
};

export default useSwrJobs;
