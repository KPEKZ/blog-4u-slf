import { InjectionToken, isDevMode, Provider } from "@angular/core";
import { Environment } from "./environment";
import { environmentDev } from "./environment-dev";

export const ENVIRONMENT_CONFIG = new InjectionToken<Environment>('ENVIRONMENT_CONFIG', {
  providedIn: 'root',
  factory: () => isDevMode() ? environmentDev : environmentDev,
});

export function provideEnvironment(config?: Environment): Provider {
  return {
    provide: ENVIRONMENT_CONFIG,
    useValue: {
      ...environmentDev,
      ...config,
    }
  };
}
