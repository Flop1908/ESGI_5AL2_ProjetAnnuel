#import <Foundation/Foundation.h>

@interface VDMEntry : NSObject {
	NSDateFormatter *dates;
    NSString *contents;
    NSString *author;
	int entryId;
	int agreeCount;
	int deserveCount;
	int commentsCount;
}

@property (nonatomic, assign) int entryId;
@property (nonatomic, assign) int commentsCount;
@property (nonatomic, assign) int agreeCount;
@property (nonatomic, assign) int deserveCount;
@property (nonatomic, assign) NSDateFormatter *date;
@property (nonatomic, retain) NSString *contents;
@property (nonatomic, retain) NSString *author;

@end

