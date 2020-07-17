import { HttpClient, HttpEventType, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { UploadModel } from "./upload.model";

@Injectable({ providedIn: "root" })
export class AppFileService {
    constructor(private readonly http: HttpClient) { }

    upload(file: File): Observable<UploadModel> {
        const formData = new FormData();
        formData.append(file.name, file);

        const request = new HttpRequest("POST", "files", formData, { reportProgress: true, });

        return new Observable((observable: any) => {
            this.http.request(request).subscribe((event: any) => {
                if (event.type === HttpEventType.Response) {
                    return observable.next(new UploadModel(event.body[0].id, 100));
                }

                if (event.type === HttpEventType.UploadProgress && event.total) {
                    const progress = Math.round(100 * event.loaded / event.total);
                    return observable.next(new UploadModel("", progress));
                }

                return observable.next(new UploadModel("", 0));
            });
        });
    }
}
