import { defineConfig } from "vite";
import solid from "vite-plugin-solid";

export default defineConfig({
	build: {
		outDir: "../SolidHybridApp.Program/wwwroot/",
		// outDir: "../SolidHybridApp.Program/Resources/Raw/ui/",
	},
	plugins: [solid()],
});
