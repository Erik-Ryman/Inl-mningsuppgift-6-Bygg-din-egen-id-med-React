import { PrivateUser } from "@/models/Authentication";
import React, { FC, useState } from "react";
import { CheckIcon, XMarkIcon } from "@heroicons/react/20/solid";
import TinderCard from "react-tinder-card";

interface UserProps {
	users: PrivateUser[];
}

const User: FC<UserProps> = ({ users }) => {
	const [currentIndex, setCurrentIndex] = useState(0);

	const handleSwipe = async (dir: string) => {
		if (dir === "left") {
			setCurrentIndex((prevIndex) => prevIndex + 1);
		} else if (dir === "right") {
			setCurrentIndex((prevIndex) => prevIndex + 1);
		}
	};

	return (
		<div className='flex flex-col justify-center items-center'>
			{users.length === 0 && <p className='text-center'>No more users</p>}
			{users.slice(currentIndex, currentIndex + 1).map((user, index) => (
				<TinderCard
					key={user.id}
					onSwipe={(dir) => handleSwipe(dir)}
					onCardLeftScreen={() => {}}
					className='absolute'
				>
					<div className='bg-slate-100 ring-2 ring-indigo-500 rounded-3xl max-w-md w-full'>
						<div className='p-4'>
							<div className='flex items-center justify-between gap-x-4'>
								<h3
									id={user.id}
									className='rounded-full bg-indigo-500 px-2.5 py-1 text-lg font-semibold leading-8 text-white'
								>
									{user.firstName} {user.lastName}
								</h3>
								<p className='font-semibold leading-5'>{user.location}</p>
							</div>
							<p className='mt-4 text-sm leading-6 text-gray-900'>{user.aboutMe}</p>

							<ul role='list' className='mt-4 leading-6 text-gray-900 grid grid-cols-2 gap-y-2'>
								{user.skills?.map((skill) => (
									<li key={skill.id}>{skill.name}</li>
								))}
							</ul>
							<div className='mt-4 flex justify-around'>
								<button
									className='p-2 rounded-full bg-red-500 text-white'
									onClick={() => {
										handleSwipe("left");
									}}
								>
									<XMarkIcon className='w-8 h-8' />
								</button>
								<button
									className='p-2 rounded-full bg-green-500 text-white'
									onClick={() => {
										handleSwipe("right");
									}}
								>
									<CheckIcon className='w-8 h-8' />
								</button>
							</div>
						</div>
					</div>
				</TinderCard>
			))}
		</div>
	);
};

export default User;
