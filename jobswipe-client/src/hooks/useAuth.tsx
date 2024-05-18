"use client";
import { useEffect } from "react";
import { useRouter } from "next/navigation";
import { AUTH } from "@/services/ApiService";

const useAuth = () => {
	const router = useRouter();

	useEffect(() => {
		const checkAuthentication = async () => {
			const jwtToken = await AUTH.getJwtToken();
			if (jwtToken) {
			} else {
				router.push("/login");
			}
		};

		checkAuthentication();
	}, [router]);

	return null;
};

export default useAuth;
