/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/knockout/knockout.d.ts" />
/// <reference path="../../typing/knockout.mapping/knockout.mapping.d.ts" />


module Hack {

    export class Marker {
        public name: string;
        public location: string;
        public id: string;

        public x_coordinate: number;
        public y_coordinate: number;

        public title: string; // name ordinacije!!!! :D
        public icon: string;
        public patientCount: number;

        constructor(Name: string, Location: string, X: number, Y: number, Title: string, Icon: string, Id: string) {
            this.name = Name;
            this.location = Location;
            this.x_coordinate = X;
            this.y_coordinate = Y;
            this.title = Title;
            this.icon = Icon;
            this.id = Id;
        }

    }
}