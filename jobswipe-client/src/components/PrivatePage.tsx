"use client";
import Job from "@/components/Job";
import Nav from "@/components/Nav";
import React, { FC, useEffect } from "react";
import useSwrJobs from "@/hooks/useSwrJobs";
import { useRouter } from "next/navigation";

const PrivatePage: FC = () => {
	const { jobs, isLoading, isError } = useSwrJobs();
	const router = useRouter();

	useEffect(() => {
		if (isError && isError.message === "403") {
			router.push("/company");
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
			{jobs && jobs.length > 0 ? <Job jobs={jobs} /> : <p className='text-center'>No more jobs</p>}
		</Nav>
	);
};

export default PrivatePage;
