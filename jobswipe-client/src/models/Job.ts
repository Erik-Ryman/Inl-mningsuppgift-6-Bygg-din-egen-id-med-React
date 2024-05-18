import { CompanyUser } from "./Authentication";
import { Skill } from "./Skill";

export interface JobDTO {
	title: string;
	description: string;
	companyId: string;
	companyUrl: string;
	finalApplicationDate: Date;
	location: string[];
	optionalSkills?: string[];
	requiredSkills: Skill[];
	salary: number;
}

export interface Job {
	id: string;
	title: string;
	description: string;
	companyId: string;
	company: CompanyUser;
	salary: string | null;
	companyUrl: string | null;
	location: string[];
	requiredSkills: Skill[];
	optionalSkills: Skill[] | null;
	finalApplicationDate: string;
}
