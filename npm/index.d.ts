declare module '@apiverve/webscreenshots' {
  export interface webscreenshotsOptions {
    api_key: string;
    secure?: boolean;
  }

  /**
   * Describes fields the current plan does not unlock. Locked fields arrive as null
   * in `data`; `locked_fields` names them, using dot paths for nested fields.
   * Absent when the plan unlocks everything.
   */
  export interface PremiumInfo {
    message: string;
    upgrade_url: string;
    locked_fields: string[];
  }

  export interface webscreenshotsResponse {
    status: string;
    error: string | null;
    data: WebsiteScreenshotData;
    code?: number;
    premium?: PremiumInfo;
  }


  interface WebsiteScreenshotData {
      width:       number | null;
      height:      number | null;
      scaleFactor: number | null;
      imageName:   null | string;
      expires:     number | null;
      url:         null | string;
      downloadURL: null | string;
  }

  export default class webscreenshotsWrapper {
    constructor(options: webscreenshotsOptions);

    execute(callback: (error: any, data: webscreenshotsResponse | null) => void): Promise<webscreenshotsResponse>;
    execute(query: Record<string, any>, callback: (error: any, data: webscreenshotsResponse | null) => void): Promise<webscreenshotsResponse>;
    execute(query?: Record<string, any>): Promise<webscreenshotsResponse>;
  }
}
