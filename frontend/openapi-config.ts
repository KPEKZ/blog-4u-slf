import { GeneratorConfig } from 'ng-openapi';
import { HttpResourcePlugin } from '@ng-openapi/http-resource';
import { ZodPlugin } from '@ng-openapi/zod';

const config: GeneratorConfig = {
  input: './swagger.json',
  output: './libs/entities/post/src/lib/api',
  options: {
    dateType: 'Date',
    enumStyle: 'enum'
  },
  plugins: [HttpResourcePlugin, ZodPlugin]
};

export default config;
