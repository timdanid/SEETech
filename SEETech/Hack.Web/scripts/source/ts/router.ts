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
            $.ajax({
                url: this.url + "GetAllCounties",
                context: document.body
            }).done((data: Array<Province>) => {
                    callback(data);
            }).fail((Error: any) => {
                    this.error(Error);
                });
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

        public getList(query: string, general: boolean, preschool : boolean, women: boolean, dental: boolean, callback: Function): void {
            $.ajax({
                url: this.url + "GetPracticesList?query=" + query + "&general=" + general + "&preschool=" + preschool + "&women=" + women + "&dental=" + dental
            }).done((data: any) => {
                    callback(data);
                }).fail((Error: any) => {
                    this.error(Error);
                });
        }

        public getDetail(id: number, callback: Function): void {
             $.ajax({
                 url: this.url + "GetPracticesDetails?id=" +id,
                context: document.body
            }).done((data: string) => {
                    callback(data);
                }).fail((Error: any) => {
                    this.error(Error);
                });
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