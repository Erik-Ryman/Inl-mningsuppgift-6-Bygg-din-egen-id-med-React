"use client";
import Nav from "@/components/Nav";
import User from "@/components/User";
import useSwrUsers from "@/hooks/useSwrUsers";
import { useRouter } from "next/navigation";
import React, { FC, useEffect } from "react";

const CompanyPage: FC = () => {
	const { users, isLoading, isError } = useSwrUsers();
	const router = useRouter();

	useEffect(() => {
		if (isError && isError.message === "403") {
			router.push("/user");
		} else if (isError && isError.message === "401") {
			router.push("/login");
		}
	}, [isError, router]);

	if (isLoading)
		return (
			<Nav>
				<div>Loading...</div>
			</Nav>
		);

	if (isError)
		return (
			<Nav>
				<div>Error loading jobs</div>
			</Nav>
		);

	return (
		<Nav>
			{users && users.length > 0 ? (
				<User users={users} />
			) : (
				<p className='text-center'>No more users</p>
			)}
		</Nav>
	);
};

export default CompanyPage;
