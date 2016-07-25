-- Common
INSERT INTO [plt].[EntityState] ([Id], [NameCode], [Order], [IsStart], [IsFinish], [IsActive], [EntityLifecycleId]) VALUES
(1, 244, 1, 1, 0, 0, 1), /* Draft */
(2, 245, 2, 1, 0, 1, 1), /* Active */
(3, 246, 3, 0, 0, 0, 1), /* Blocked */
(4, 247, 4, 0, 1, 0, 1) /* Deleted */
