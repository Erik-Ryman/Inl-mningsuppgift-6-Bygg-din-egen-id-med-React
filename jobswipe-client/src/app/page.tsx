"use client";
import { useEffect, useState } from "react";
import jwt from "jsonwebtoken";
import { useRouter } from "next/navigation";
import { AUTH } from "@/services/ApiService";

export default function HomePage() {
	const router = useRouter();
	const [isAuthChecked, setIsAuthChecked] = useState(false);

	useEffect(() => {
		async function checkAuth() {
			const token = await AUTH.getJwtToken();
			if (token) {
				const decodedToken = jwt.decode(token);
				if (decodedToken && typeof decodedToken === "object" && !Array.isArray(decodedToken)) {
					let roles = decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
					if (typeof roles === "string") {
						roles = [roles];
					}
					if (roles.includes("Private")) {
						router.push("/user");
					} else if (roles.includes("Company")) {
						router.push("/company");
					} else {
						router.push("/login");
					}
				}
			} else {
				router.push("/login");
			}
			setIsAuthChecked(true);
		}
		checkAuth();
	}, [router]);

	if (!isAuthChecked) {
		return <div>Loading...</div>; // Or some loading spinner
	}

	return null;
}
