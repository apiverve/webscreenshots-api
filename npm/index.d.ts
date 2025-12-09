declare module '@apiverve/webscreenshots' {
  export interface webscreenshotsOptions {
    api_key: string;
    secure?: boolean;
  }

  export interface webscreenshotsResponse {
    status: string;
    error: string | null;
    data: WebsiteScreenshotData;
    code?: number;
  }


  interface WebsiteScreenshotData {
      width:       number;
      height:      number;
      scaleFactor: number;
      imageName:   string;
      expires:     number;
      url:         string;
      downloadURL: string;
  }

  export default class webscreenshotsWrapper {
    constructor(options: webscreenshotsOptions);

    execute(callback: (error: any, data: webscreenshotsResponse | null) => void): Promise<webscreenshotsResponse>;
    execute(query: Record<string, any>, callback: (error: any, data: webscreenshotsResponse | null) => void): Promise<webscreenshotsResponse>;
    execute(query?: Record<string, any>): Promise<webscreenshotsResponse>;
  }
}
