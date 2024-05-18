import { UserCircleIcon, HomeIcon, ChatBubbleOvalLeftIcon } from "@heroicons/react/24/outline";
import Image from "next/image";
import Link from "next/link";
import React, { FC, ReactNode } from "react";
import Logo from "../../public/JobSwipeLogo.png";

interface NavProps {
	children: ReactNode;
}

const Nav: FC<NavProps> = ({ children }) => {
	return (
		<div className='flex flex-col h-screen justify-between overflow-hidden'>
			<header className='p-3 bg-gray-100 border-b border-gray-200 flex items-center gap-2 justify-center'>
				<Image src={Logo} alt='JobSwipe Logo' width={40} height={40} className='rounded' />
				<h1 className='text-2xl font-bold text-center'>JobSwipe</h1>
			</header>
			<div className='flex items-center justify-center p-4 overflow-auto flex-grow'>{children}</div>
			<div className='flex justify-center gap-12 p-3 bg-gray-100 border-t border-gray-200 bottom-0 w-full'>
				<Link href={"/chat"} className='px-4 py-2 hover:text-indigo-500'>
					<ChatBubbleOvalLeftIcon className='w-8 h-8' />
				</Link>
				<Link href={"/"} className='px-4 py-2 hover:text-indigo-500'>
					<HomeIcon className='w-8 h-8' />
				</Link>
				<Link href={"/profile"} className='px-4 py-2 '>
					<UserCircleIcon className='h-8 w-8 hover:text-indigo-500' />
				</Link>
			</div>
		</div>
	);
};

export default Nav;
