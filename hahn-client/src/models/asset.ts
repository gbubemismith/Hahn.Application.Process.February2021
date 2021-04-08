export class Asset
{
    constructor() {
        this.id = 0,
        this.assetName = "",
        this.countryOfDepartment = "",
        this.eMailAdressOfDepartment = "",
        this.department = "",
        this.isBroken = false
    }

    id: number;
    assetName: string;
    department: string;
    countryOfDepartment: string;
    eMailAdressOfDepartment: string;
    purchaseDate: Date;
    isBroken:boolean;

    //gsmith add and test
    public initialAssetLoad()
    {
        let result = this.assetName !== "" &&
        this.eMailAdressOfDepartment !== "" &&
        this.department !== "" &&
        this.countryOfDepartment !== "" &&
        this.purchaseDate !== undefined
        return result;
    }
}