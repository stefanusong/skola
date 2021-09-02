export class SignUpDto {
  FullName!: string;
  Email!: string;
  Password!: string;
  ConfirmedPassword!: string;
}

export class SignInDto {
  Email!: string;
  Password!: string;
}

export class CreateTermDto {
  userId!: string;
  grade!: number;
  department!: number;
}

export class CreateSubjectDto {
  termId!: string;
  subjectName!: string;
}
