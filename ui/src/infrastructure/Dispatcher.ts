﻿declare const DotNet: any;

class Dispatcher {
	public dispatch() {
		// DotNet.invokeMethodAsync("__dispatch", "CallMeFromJs", "ABC").then((data) => {
		// 	console.log(data);
		// });
	}
}

export const dispatcher = new Dispatcher();
