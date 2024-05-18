import React, { FC, useState } from "react";
import { Job as JobType } from "../models/Job";
import { CheckIcon, XMarkIcon } from "@heroicons/react/20/solid";
import TinderCard from "react-tinder-card";

interface JobProps {
	jobs: JobType[];
}

const Job: FC<JobProps> = ({ jobs }) => {
	const [currentJobIndex, setCurrentJobIndex] = useState(0);

	const handleSwipe = (dir: string) => {
		if (dir === "left") {
			setCurrentJobIndex((prevIndex) => prevIndex + 1);
		} else if (dir === "right") {
			setCurrentJobIndex((prevIndex) => prevIndex + 1);
		}
	};

	return (
		<div className='flex flex-col justify-center items-center'>
			{jobs.length === 0 && <p className='text-center'>No more jobs</p>}
			{jobs.slice(currentJobIndex, currentJobIndex + 1).map((job, index) => (
				<TinderCard
					key={job.id}
					onSwipe={handleSwipe}
					onCardLeftScreen={() => {}}
					className='absolute'
				>
					<div className='bg-slate-100 ring-2 ring-indigo-500 rounded-3xl max-w-md w-full'>
						<div className='p-4'>
							<div className='flex items-center justify-between gap-x-4'>
								<h3
									id={job.id}
									className='rounded-full bg-indigo-500 px-2.5 py-1 text-lg font-semibold leading-8 text-white'
								>
									{job.title}
								</h3>
								<p className='font-semibold leading-5'>{job.location}</p>
							</div>
							<p className='mt-4 text-sm leading-6 text-gray-900'>{job.description}</p>
							<p className='mt-4 flex items-baseline gap-x-1'>
								<span className='text-xl font-semibold tracking-tight'>{job.salary}</span>
								<span className='font-semibold leading-6 text-gray-900'>/month</span>
							</p>

							<ul role='list' className='mt-4 leading-6 text-gray-900 grid grid-cols-2 gap-y-2'>
								{job.requiredSkills.map((skill) => (
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
export default Job;
