﻿module Hack {

    export class Router {

        constructor(url: string) {
            this.url = url;
        }

        private url: string;

        public error(error: any) {
            console.log("ERROR", error);
        }

        public getProvinces(callback: Function): void {

            callback(new Array<Province>(new Province("a", "abc")));
            //$.ajax({
            //    url: this.url + "",
            //    context: document.body
            //}).done((data: Array<Province>) => {
            //        callback(data);
            //}).fail((Error: any) => {
            //        this.error(Error);
            //    });
        }

        public getCities(provinceName: string, callback: Function): void {
            $.ajax({
                url: this.url + "GetCitiesForCounty?countyname=" + provinceName,
                context: document.body
            }).done((data: Array<City>) => {
                   callback(data);
                }).fail((Error: any) => {
                    this.error(Error);
                });
        }

        public getList(json: string, callback: Function): void {
            var a = {
                href: "/#/detail/id/",
                name: "ime",
                location: "abaafccacac"
            };
            callback(new Array<any>(a, a));
             //$.ajax({
            //    url: this.url + "",
            //    context: document.body
            //}).done((data: string) => {
            //        callback(data);
            //    }).fail((Error: any) => {
            //        this.error(Error);
            //    });
        }

        public getDetail(id: number, callback: Function): void {
            var a = {
            };
            callback(new Array<any>(a, a));
             //$.ajax({
            //    url: this.url + "",
            //    context: document.body
            //}).done((data: string) => {
            //        callback(data);
            //    }).fail((Error: any) => {
            //        this.error(Error);
            //    });
        }
        //_lat, _lng, _title, _infoText,_icon
        public getMarkers(callback: Function): void {
            $.ajax({
                url: this.url + "getMarkers",
                context: document.body
            }).done((data: Array<Marker>) => {
                callback(data);
                }).fail((Error: any) => {
                    this.error(Error);
                });
        }

    }

}