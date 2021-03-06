using System;

namespace EventStore.Client.Streams {
	partial class ReadReq {
		partial class Types {
			partial class Options {
				partial class Types {
					partial class StreamOptions {
						public static StreamOptions FromStreamNameAndRevision(
							string streamName,
							StreamPosition streamRevision) {
							if (streamName == null) {
								throw new ArgumentNullException(nameof(streamName));
							}

							if (streamRevision == StreamPosition.End) {
								return new StreamOptions {
									StreamIdentifier = streamName,
									End = new Empty()
								};
							}

							if (streamRevision == StreamPosition.Start) {
								return new StreamOptions {
									StreamIdentifier = streamName,
									Start = new Empty()
								};
							}

							return new StreamOptions {
								StreamIdentifier = streamName,
								Revision = streamRevision
							};
						}
					}

					partial class AllOptions {
						public static AllOptions FromPosition(Client.Position position) {
							if (position == Client.Position.End) {
								return new AllOptions {
									End = new Empty()
								};
							}

							if (position == Client.Position.Start) {
								return new AllOptions {
									Start = new Empty()
								};
							}

							return new AllOptions {
								Position = new Position {
									CommitPosition = position.CommitPosition,
									PreparePosition = position.PreparePosition
								}
							};
						}
					}
				}
			}
		}
	}
}
