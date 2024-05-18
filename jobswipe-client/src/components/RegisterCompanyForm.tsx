"use client";
import { AUTH } from "@/services/ApiService";
import Link from "next/link";
import { useRouter } from "next/navigation";
import React, { FC, useState } from "react";

const RegisterForm: FC = () => {
	const [registerData, setRegisterData] = useState({
		email: "",
		password: "",
		companyName: "",
		website: "",
		location: "",
		aboutCompany: "",
	});
	const router = useRouter();

	// Check if all fields are filled in
	const isFormValid = () => {
		return (
			registerData.email.length > 0 &&
			registerData.password.length > 0 &&
			registerData.companyName.length > 0 &&
			registerData.website.length > 0 &&
			registerData.location.length > 0 &&
			registerData.aboutCompany.length > 0
		);
	};

	const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		setRegisterData({ ...registerData, [e.target.name]: e.target.value });
	};

	async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
		const locationArray = registerData.location.split(",").map((location) => location.trim());
		const modifiedRegisterData = { ...registerData, location: locationArray };
		e.preventDefault();
		try {
			await AUTH.registerCompanyUser(modifiedRegisterData);
			const response = await AUTH.authenticateUser(registerData.email, registerData.password);
			AUTH.handleAuthResponse(response);
			router.push("/");
		} catch (error) {
			console.error(error);
		}
	}

	return (
		<div className='min-h-screen flex flex-col justify-center md:py-12 py-6 md:px-6 lg:px-8'>
			<div className='sm:mx-auto sm:w-full sm:max-w-md'>
				<div className='md:bg-slate-300 py-8 px-6 md:shadow-md sm:rounded-lg sm:px-10'>
					<div className='sm:mx-auto sm:w-full sm:max-w-md mb-6'>
						<h2 className='text-center text-2xl font-extrabold'>Sign up as a company</h2>
					</div>
					<form onSubmit={handleSubmit} className='space-y-6'>
						<div>
							<label htmlFor='email' className='block text-sm font-medium text-gray-700'>
								Email address
							</label>
							<div className='mt-1'>
								<input
									id='email'
									name='email'
									type='email'
									autoComplete='email'
									required
									value={registerData.email}
									onChange={handleChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<label htmlFor='password' className='block text-sm font-medium text-gray-700'>
								Password
							</label>
							<div className='mt-1'>
								<input
									id='password'
									name='password'
									type='password'
									autoComplete='current-password'
									required
									value={registerData.password}
									onChange={handleChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<label htmlFor='companyName' className='block text-sm font-medium text-gray-700'>
								Company Name
							</label>
							<div className='mt-1'>
								<input
									id='companyName'
									name='companyName'
									type='companyName'
									autoComplete='companyName'
									required
									value={registerData.companyName}
									onChange={handleChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<label htmlFor='website' className='block text-sm font-medium text-gray-700'>
								Website
							</label>
							<div className='mt-1'>
								<input
									id='website'
									name='website'
									type='website'
									autoComplete='website'
									required
									value={registerData.website}
									onChange={handleChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<label htmlFor='location' className='block text-sm font-medium text-gray-700'>
								Location <span className='text-sm'>(if multiple, separate by commas)</span>
							</label>
							<div className='mt-1'>
								<input
									id='location'
									name='location'
									type='location'
									autoComplete='location'
									required
									value={registerData.location}
									onChange={handleChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<label htmlFor='aboutCompany' className='block text-sm font-medium text-gray-700'>
								About your company
							</label>
							<div className='mt-1'>
								<input
									id='aboutCompany'
									name='aboutCompany'
									type='aboutCompany'
									autoComplete='aboutCompany'
									required
									value={registerData.aboutCompany}
									onChange={handleChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<input
								type='submit'
								className='w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 disabled:opacity-50 disabled::cursor-not-allowed'
								value={"Register"}
								disabled={!isFormValid()}
							/>
						</div>
						<div>
							<Link
								href={"/login"}
								className='w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500'
							>
								Go to login
							</Link>
						</div>
						<div>
							<Link
								href={"/signup"}
								className='w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500'
							>
								Register a private user
							</Link>
						</div>
					</form>
				</div>
			</div>
		</div>
	);
};

export default RegisterForm;
