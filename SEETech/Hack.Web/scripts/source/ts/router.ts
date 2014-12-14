module Hack {

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

        public getCities(callback: Function): void {
            callback(new Array<City>(new City("b", "abcb")));
            //$.ajax({
            //    url: this.url + "",
            //    context: document.body
            //}).done((data: Array<City>) => {
            //        callback(data);
            //    }).fail((Error: any) => {
            //        this.error(Error);
            //    });
        }

        public getList(json: string, callback: Function): void {
            var a = {
                href: "abc",
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



    }

}