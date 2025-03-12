import { build } from 'esbuild'

var options =
{
  entryPoints: ['./build/WebSharper.ChartJs.Testing.js'],
  bundle: true,
  minify: true,
  format: 'iife',
  outfile: '../dist/Content/WebSharper.ChartJs.Testing.min.js',
  globalName: 'wsbundle'
};

build(options);

