export interface spInstructions {
    name: string;
    steps: Step[];
}

interface Step {
    number: number,
    step: string,
    ingredients: any[],
    equipment: any[],
    length: Length
}

interface Length {
    number: number,
    unit: string
}