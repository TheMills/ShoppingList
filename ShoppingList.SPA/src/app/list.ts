import { Item } from './item';

export class List {
    public id: number;
    public name: string;
    public listItems: Item[];

    public timeCreated: DateTimeFormat;
    public timeModified: DateTimeFormat;

    constructor(id, text, timeCreated, timeModified) {
        this.id = id;
        this.name = text;
        this.timeCreated = timeCreated;
        this.timeModified = timeModified;
    }
}
