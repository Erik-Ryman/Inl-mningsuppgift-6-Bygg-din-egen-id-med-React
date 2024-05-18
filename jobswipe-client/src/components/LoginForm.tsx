"use client";
import { AUTH as AUTH } from "@/services/ApiService";
import Link from "next/link";
import { useRouter } from "next/navigation";
import React, { useState } from "react";

const LoginForm = () => {
	const [email, setEmail] = useState("");
	const [password, setPassword] = useState("");
	const [error, setError] = useState("");
	const router = useRouter();

	const isFormValid = () => {
		return email.length > 0 && password.length > 0;
	};

	const handleEmailChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		setEmail(e.target.value);
	};

	const handlePasswordChange = (e: React.ChangeEvent<HTMLInputElement>) => {
		setPassword(e.target.value);
	};

	async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
		e.preventDefault();
		try {
			const response = await AUTH.authenticateUser(email, password);
			if (response) {
				AUTH.handleAuthResponse(response);
				router.push("/");
			}
		} catch (error) {
			console.error(error);
			setError("Authentication failed. Please check your email and password.");
		}
	}

	return (
		<div className='min-h-screen flex flex-col justify-center py-12 sm:px-6 lg:px-8'>
			<div className='sm:mx-auto sm:w-full sm:max-w-md'>
				<div className='md:bg-slate-300 py-8 px-6 md:shadow-md sm:rounded-lg sm:px-10'>
					<div className='sm:mx-auto px-6 py-2 mb-4'>
						<h2 className='text-center text-2xl font-extrabold '>Sign in to your account</h2>
					</div>
					{error && <p className='text-red-700 mb-4 text-xs font-semibold text-center'>{error}</p>}
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
									value={email}
									onChange={handleEmailChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-s'
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
									value={password}
									onChange={handlePasswordChange}
									className='appearance-none block w-full px-3 py-2 border border-gray-700 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm '
								/>
							</div>
						</div>

						<div>
							<input
								type='submit'
								className='w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 disabled:opacity-50 disabled:cursor-not-allowed'
								value={"Sign in"}
								disabled={!isFormValid()}
							/>
						</div>
						<div>
							<Link
								href={"/signup"}
								className='w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-indigo-600 hover:bg-indigo-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500'
							>
								Register
							</Link>
						</div>
					</form>
				</div>
			</div>
		</div>
	);
};

export default LoginForm;
