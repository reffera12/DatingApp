import { Injectable } from "@angular/core";

const token_Key='auth-token';
const user_Key='auth-user';

@Injectable({
    providedIn:"root"
})
export class TokenStorageService{
    constructor(){}

    signOut():void{
        sessionStorage.clear();
    }
    public saveToken(token:string):void{
        sessionStorage.removeItem(token_Key);
        sessionStorage.setItem(token_Key,token);
    }
    public getToken():string|null{
        return sessionStorage.getItem(token_Key);
    }

    public saveUser(user:any):void{
        sessionStorage.removeItem(user_Key);
        sessionStorage.setItem(user_Key,JSON.stringify(user));
    }

    public getUser(): any {
        const user = sessionStorage.getItem(user_Key);
        if(user){
            return JSON.parse(user);
        }
        return {};
    }

    public getUserRoles(): string[]{
        return this.getUser().roles ?? [];
    }

    public isUserLoggedIn():boolean{
        return sessionStorage.getItem(token_Key)!=null && sessionStorage.getItem(user_Key)!=null; 
    }

    public hasRole(Roles: string []): boolean {
        return Roles && Roles.filter(value => this.getUserRoles().includes(value)).length>0;
    }
}