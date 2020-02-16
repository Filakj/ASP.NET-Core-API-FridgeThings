export interface spRecipe {
    id:number,
    title:string,
    image:string,
    imageType:string,
    usedIngredientCount:number,
    missedIngredientCount:number,
    missedIngredients:MissedIngredient[],
    usedIngredients:UsedIngredient[],
    unusedIngredients:UnusedIngredient[],
    likes:number
}

interface UnusedIngredient {
    id:number,
    amount:number,
    unit:string,
    unitLong:string,
    unitShort:string,
    aisle:string,
    name:string,
    original:string,
    originalString:string,
    originalName:string,
    metaInformation:any[],
    meta:any[],
    image:string
}

interface UsedIngredient {
    id:number,
    amount:number,
    unit:string,
    unitLong:string,
    unitShort:string,
    aisle:string,
    name:string,
    original:string,
    originalString:string,
    originalName:string,
    metaInformation:any[],
    meta:any[],
    image:string
}

interface MissedIngredient {
    id:number,
    amount:number,
    unit:string,
    unitLong:string,
    unitShort:string,
    aisle:string,
    name:string,
    original:string,
    originalString:string,
    originalName:string,
    metaInformation:any[],
    meta:string[],
    extendedName:string,
    image:string
}