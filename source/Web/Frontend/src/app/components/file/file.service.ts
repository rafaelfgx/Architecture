import { HttpClient, HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import AppFile from "./file";

@Injectable({ providedIn: "root" })
export default class AppFileService {
    constructor(private readonly http: HttpClient) { }

    upload(file: File): Observable<AppFile> {
        const formData = new FormData();
        formData.append(file.name, file);

        const request = new HttpRequest("POST", "api/files", formData, { reportProgress: true });

        return new Observable((observable: any) => {
            this.http.request(request).subscribe((event: any) => {
                if (event.type === HttpEventType.Response) {
                    return observable.next({ id: event.body[0].id, progress: 100 });
                }

                if (event.type === HttpEventType.UploadProgress && event.total) {
                    return observable.next({ progress: Math.round(100 * event.loaded / event.total) });
                }

                return observable.next({ progress: 0 });
            });
        });
    }
}
