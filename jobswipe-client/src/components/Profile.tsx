"use client";
import Nav from "@/components/Nav";
import { AUTH } from "@/services/ApiService";
import { useRouter } from "next/navigation";
import React, { FC } from "react";
import useSwrUser from "@/hooks/useSwrSingleUser";
import { Skill } from "@/models/Skill";

const Profile: FC = () => {
	const router = useRouter();
	const handleLogout = () => {
		AUTH.logout();
		router.push("/login");
	};
	const email = localStorage.getItem("email");
	if (email == null) {
		router.push("/login");
	}
	const { user, isLoading, isError } = useSwrUser(email as string);

	if (isLoading)
		return (
			<Nav>
				<div>Loading...</div>
			</Nav>
		);

	if (isError)
		return (
			<Nav>
				<div>Error loading user</div>
			</Nav>
		);

	return (
		<Nav>
			<div className='min-h-screen flex flex-col justify-center py-12 sm:px-6 lg:px-8'>
				<div className='sm:mx-auto sm:w-full sm:max-w-md'>
					<div className='md:bg-slate-100 py-8 px-6 md:shadow-md sm:rounded-lg sm:px-10'>
						<div className='sm:mx-auto px-6 py-2 mb-4'>
							<h2 className='text-center text-2xl font-extrabold border-b-indigo-500 border-b-2'>
								Account information
							</h2>
						</div>

						{user && (
							<div className='flex flex-col gap-y-2'>
								<p className='px-2 py-1'>
									<strong>Email:</strong> {user.email}
								</p>
								{"firstName" in user ? (
									<>
										<p className='px-2 py-1'>
											<strong>First Name:</strong> {user.firstName}
										</p>
										<p className='px-2 py-1'>
											<strong>Last Name:</strong> {user.lastName}
										</p>
										<div className='flex items-center px-2 py-1'>
											<strong>Location:</strong>{" "}
											<ul className='flex flex-wrap ml-2'>
												{user.location.map((location: string) => (
													<li key={location} className='mr-2'>
														{location}
													</li>
												))}
											</ul>
										</div>
										<p className='px-2 py-1'>
											<strong>About Me:</strong> {user.aboutMe}
										</p>
										<div className='flex items-center px-2 py-1'>
											<strong>Skills:</strong>{" "}
											{user.skills.length > 0 ? (
												<ul className='flex flex-wrap ml-2'>
													{user.skills.map((skill: Skill) => (
														<li key={skill.id} className='mr-2'>
															{skill.name}
														</li>
													))}
												</ul>
											) : (
												<p className='ml-2'>You should add some skills!</p>
											)}
										</div>
									</>
								) : (
									<>
										<p className='px-2 py-1'>
											<strong>Company Name:</strong> {user.companyName}
										</p>
										<p className='px-2 py-1'>
											<strong>About Company:</strong> {user.aboutCompany}
										</p>
										<p className='px-2 py-1'>
											<strong>Website:</strong> {user.website}
										</p>
										<div className='flex items-center px-2 py-1'>
											<strong>Location(s):</strong>{" "}
											<ul className='flex flex-wrap ml-2'>
												{user.location.map((location: string) => (
													<li key={location} className='mr-2'>
														{location}
													</li>
												))}
											</ul>
										</div>
									</>
								)}
							</div>
						)}

						<button
							onClick={handleLogout}
							className='mt-4 ml-2 bg-indigo-500 hover:bg-indigo-700 text-white font-bold py-2 px-4 rounded'
						>
							Log out
						</button>
					</div>
				</div>
			</div>
		</Nav>
	);
};

export default Profile;
