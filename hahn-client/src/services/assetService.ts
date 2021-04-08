import { HttpClient, json } from 'aurelia-fetch-client';
import { Asset } from '../models/asset';
import {inject} from 'aurelia-framework';


@inject(HttpClient)
export class AssetService
{
    constructor(private http: HttpClient){
        const baseUrl = "http://localhost:8000/api/v1/";

        http.configure(config => config.withBaseUrl(baseUrl));
    }

    createAsset(asset: Asset)
    {
        return this.http.fetch('asset', {
            method: 'post',
            body: json(asset)
        })
        .then(response => response.json())
        .then(createdAsset => {
            return createdAsset
        });

    }

   
    
}
