import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Http, Response, RequestOptions, Headers, URLSearchParams } from "@angular/http";



@Component({
    selector: "app-twitter-postagemporhashtag",
    templateUrl: "./twitter-postagemporhashtag.html"
})
export class TwitterPostagemporHashTagComponent implements OnInit {

    public error: boolean;
    public message: string;
    public role: string;
    public roleRoute: string;
    public registros: any[];
    public getData: any;

    constructor(private router: Router, private http: Http) { }

    getTop5Usuario() {
        return this.http.get('http://edsonjmartins-eval-test.apigee.net/lista-de-postagem-por-hashtag')
            .map(res => res.json());
    }

    onTop5Usuario() {
        this.getTop5Usuario()
            .subscribe(
                data => this.registros = data,
                err => this.error = true,
                () => console.log("OK")
            );
    }

    ngOnInit() {
        this.error = false;
        this.roleRoute = this.router.url.split("/")[1];
        this.role = this.roleRoute.replace("-", " ").replace(/\b\w/g, l => l.toUpperCase());

        this.onTop5Usuario();
    }
}
