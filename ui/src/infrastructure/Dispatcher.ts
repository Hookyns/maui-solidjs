declare const DotNet: any;

class Dispatcher {
	public async dispatch<TMessage extends object | void = void, TResult extends object | void = void>(
		...message: TMessage extends void ? ["You have to specify generic parameters."] : [TMessage]
	): Promise<TResult> {
		const result = await DotNet.invokeMethodAsync(
			"SolidHybridApp.Program",
			"DispatchMessage",
			"SolidHybridApp.Program.MainPage+Test",
			message[0]
		);

		if (result.hasOwnProperty("__DispatchError")) {
			throw new Error(result["__DispatchError"]);
		}

		return result;
		// DotNet.invokeMethodAsync("__dispatch", "CallMeFromJs", "ABC").then((data) => {
		// 	console.log(data);
		// });
	}
}

export const dispatcher = new Dispatcher();
