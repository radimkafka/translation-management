import { AxiosRequestConfig } from "axios";

export default class clientBase {
  protected async transformOptions(options: AxiosRequestConfig): Promise<AxiosRequestConfig> {
    options = {
      ...options,
      transformResponse: [],
    };
    return options;
  }
}
