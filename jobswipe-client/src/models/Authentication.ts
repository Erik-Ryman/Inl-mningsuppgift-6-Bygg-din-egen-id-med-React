import { Job } from "./Job";
import { Match } from "./Match";
import { Skill } from "./Skill";

export interface RegisterCompanyUserDTO {
	email: string;
	password: string;
	companyName: string;
	location: string[];
	aboutCompany: string;
	website: string;
}

export interface RegisterPrivateUserDTO {
	email: string;
	password: string;
	firstName: string;
	lastName: string;
	location: string[];
	aboutMe: string;
}

export interface LoginDTO {
	email: string;
	password: string;
}

export interface LoginResponse {
	JwtToken: string;
	refreshToken: string;
	Expiration: Date;
}

export interface RefreshDTO {
	refreshToken: string;
	JwtToken: string;
}

export interface PrivateUser {
	firstName: string;
	lastName: string;
	aboutMe: string;
	skills: Skill[];
	id: string;
	email: string;
	passwordHash: string;
	location: string[];
	matches: Match[];
	refreshToken: string;
	refreshTokenExpiry: string;
	created: string;
}

export interface CompanyUser {
	companyName: string;
	aboutCompany: string;
	website: string;
	jobs: Job[];
	id: string;
	email: string;
	passwordHash: string;
	location: string[];
	matches: Match[];
	refreshToken: string;
	refreshTokenExpiry: string;
	created: string;
}
